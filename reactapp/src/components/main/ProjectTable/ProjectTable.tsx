import React from 'react'
import {
  Project,
  ProjectService,
  ProjectStatusEnum,
  ProjectStatusEnumService,
  ProjectDealTypeEnum,
  ProjectDealTypeEnumService
} from '../../../services/openapi'

import Table from '@mui/material/Table'
import TableBody from '@mui/material/TableBody'
import TableCell from '@mui/material/TableCell'
import TableContainer from '@mui/material/TableContainer'
import TableHead from '@mui/material/TableHead'
import TableRow from '@mui/material/TableRow'
import Paper from '@mui/material/Paper'

class TableStyle {
  align: 'inherit' | 'left' | 'center' | 'right' | 'justify' = 'right'
}

class ProjectTable extends React.Component {
  TableStyle: TableStyle = new TableStyle()
  Projects: Project[] = []
  DealTypeEnum: ProjectDealTypeEnum[] = []
  StatusEnum: ProjectStatusEnum[] = []

  async componentDidMount () {
    // make fetch request
    ProjectService.getProject().then(
      data => {
        this.Projects = data
        this.setState({})
      },
      error => {}
    )
    ProjectDealTypeEnumService.getProjectDealTypeEnum().then(
      data => {
        this.DealTypeEnum = data
      },
      error => {}
    )
    ProjectStatusEnumService.getProjectStatusEnum().then(
      data => {
        this.StatusEnum = data
      },
      error => {}
    )
  }

  componentWillUnmount () {
    // make fetch request
  }

  render () {
    return (
      <>
        <div style={{ height: 600, width: '100%' }}>{this.table()}</div>
      </>
    )
  }

  table () {
    return (
      <>
        <TableContainer component={Paper}>
          <Table sx={{ minWidth: 650 }} aria-label='simple table'>
            <TableHead>{this.headerRow()}</TableHead>
            <TableBody>{this.Projects.map(row => this.row(row))}</TableBody>
          </Table>
        </TableContainer>
      </>
    )
  }

  headerRow () {
    const headers = [
      'id',
      'companyId',
      'groupId',
      'number',
      'name',
      'dealType',
      'status',
      'acquisitionDate',
      'monthsAcquired',
      'number3Lcode',
      'kw'
    ]
    return (
      <>
        <TableRow>
          {headers.map(header => (
            <TableCell align={this.TableStyle.align}>{header}</TableCell>
          ))}
        </TableRow>
      </>
    )
  }

  row (project: Project) {
    return (
      <>
        <TableRow
          key={project.id}
          sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
        >
          {/* <TableCell component='th' scope='row'>
            {row.name}
          </TableCell> */}
          <TableCell align={this.TableStyle.align}>{project.id}</TableCell>
          <TableCell align={this.TableStyle.align}>{project.companyId}</TableCell>
          <TableCell align={this.TableStyle.align}>{project.groupId}</TableCell>
          <TableCell align={this.TableStyle.align}>{project.number}</TableCell>
          <TableCell align={this.TableStyle.align}>{project.name}</TableCell>
          <TableCell align={this.TableStyle.align}>
            {this.getDealTypeEnum(project.dealTypeId)}
          </TableCell>
          <TableCell align={this.TableStyle.align}>
            {this.getStatusEnum(project.statusId)}
          </TableCell>
          <TableCell align={this.TableStyle.align}>{project.acquisitionDate}</TableCell>
          <TableCell align={this.TableStyle.align}>{project.acquisitionDate}</TableCell>
          <TableCell align={this.TableStyle.align}>{project.monthsAcquired}</TableCell>
          <TableCell align={this.TableStyle.align}>{project.number3Lcode}</TableCell>
          <TableCell align={this.TableStyle.align}>{project.kw}</TableCell>
        </TableRow>
      </>
    )
  }

  getStatusEnum (id?: number): string {
    let enumValue = this.StatusEnum.find(item => item.id === id)
    return enumValue?.value ?? ''
  }

  getDealTypeEnum (id?: number): string {
    let enumValue = this.DealTypeEnum.find(item => item.id === id)
    return enumValue?.value ?? ''
  }
}

export default ProjectTable
